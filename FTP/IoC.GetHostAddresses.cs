using DnsClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Kaven.Standard
{
    internal partial class IoC: DefaultIoC
    {
        private readonly LookupClient _osClient = new();
        private readonly ConcurrentDictionary<IPAddress, LookupClient> _clients = [];

        public override IEnumerable<IPAddress> GetHostAddresses(string host, IPAddress? server = null)
        {
            LookupClient lookup;
            if (server != null)
            {
                lookup = _clients.GetOrAdd(server, p => new LookupClient(p));
            }
            else
            {
                lookup = _osClient;
            }

            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var current = host;

            while (!visited.Contains(current))
            {
                visited.Add(current);

                // CNAME
                var cnameResult = lookup.Query(current, DnsClient.QueryType.CNAME);
                var cname = cnameResult.Answers.CnameRecords().FirstOrDefault();
                if (cname != null)
                {
                    current = cname.CanonicalName;
                    continue; // follow the CNAME
                }

                // A
                var aResult = lookup.Query(current, DnsClient.QueryType.A);
                foreach (var a in aResult.Answers.ARecords())
                {
                    yield return a.Address;
                }

                // AAAA
                var aaaaResult = lookup.Query(current, DnsClient.QueryType.AAAA);
                foreach (var aaaa in aaaaResult.Answers.AaaaRecords())
                {
                    yield return aaaa.Address;
                }
            }
        }       
    }
}
