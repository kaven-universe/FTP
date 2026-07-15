# [FTP](https://github.com/kaven-universe/FTP)

A dedicated FTP server built for NAT environments, with support for passive mode, FTPS, and custom DNS resolution.

## Key Features

- FTP command support: Implements essential FTP commands (not all commands are fully supported).
- Encryption support:
  - Partial support for explicit and implicit FTPS.
  - TLS encryption available for control connections.
  - TLS encryption for data connections is supported only in passive mode.
- Passive mode configuration:
  - `PasvServerAddress` can be set to either an IP address or a domain name.
  - When a domain name is used, it is automatically resolved to an IP address, which is useful for Dynamic DNS (DDNS).
- Custom DNS resolution:
  - Use the `DNS` setting to resolve `PasvServerAddress` through a custom DNS server.

## Docker

[kavenzero/ftp](https://hub.docker.com/r/kavenzero/ftp/tags)

```sh
# pull the image
docker pull kavenzero/ftp

# run the container and expose FTP ports
# map host directories for configuration and files
docker run -d --name ftp-server \
  -p 21:21 \
  -p 5555-5655:5555-5655 \
  -v "$(pwd)/config:/App/Configuration" \
  -v "$(pwd)/files:/App/Files" \
  -v "$(pwd)/logs:/App/Log" \
  kavenzero/ftp

# verify the container is running
docker ps --filter "name=ftp-server"
```

## Configuration

> If the FTP configuration file is missing, the server will generate a default configuration file at startup.

> If `CertificateFile` and `PrivateKeyFile` do not exist, the server will generate them automatically using OpenSSL.

> `AllowClearProtectionLevelOnDataConnection` controls whether a user is allowed to use a clear-data-connection mode when the control connection is protected by TLS. Set it to `false` for stricter FTPS behavior, which requires the client to use explicit encryption for the data connection, and to `true` only when compatibility with certain clients or legacy transfers requires it.

`/App/Configuration/FTP.kcf`

```json
{
  "Port": 21,
  "PasvServerAddress": "my.ftp.com",
  "PasvPorts": "5555,5600-5655",
  "Users": [
    {
      "UserName": "admin",
      "Password": "2d;:Z8|xm Wr",
      "Paths": [
        {
          "VirtualPath": "/",
          "RealPath": "/App/Files"
        }
      ],
      "Permissions": "List, Download, Upload, Delete, Rename, CreateDirectory, DeleteDirectory",
      "Disabled": false,
      "MergePermissions": false,
      "AllowClearProtectionLevelOnDataConnection": false
    },
    {
      "UserName": "anonymous",
      "Paths": [
        {
          "VirtualPath": "/",
          "RealPath": "/App/Files"
        }
      ],
      "Permissions": "List, Download",
      "Disabled": false,
      "MergePermissions": true,
      "AllowClearProtectionLevelOnDataConnection": true
    }
  ],
  "ImplicitTls": false,
  "EnableActiveMode": false,
  "DNS": "8.8.8.8",
  "EnableTls": true,
  "CertificateFile": "certificate.crt",
  "PrivateKeyFile": "privateKey.key"
}
```

## Other

[.NET tool](https://www.nuget.org/packages/KCmd/#ftp-server)
