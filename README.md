# [FTP](https://github.com/kaven-universe/FTP)

## Dedicated FTP Server for NAT Environments  

This server is specifically designed for users operating behind NAT (Network Address Translation).  

**Key Features:**  

- **FTP command support**: Implements essential FTP commands (not all commands are fully supported).  
- **Encryption support**:  
  - Partial support for explicit and implicit FTPS.  
  - TLS encryption available for control connections.  
  - TLS encryption for data connections is supported **only in passive mode**.  
- **Passive mode configuration**:  
  - `PasvServerAddress` can be set to either an IP address or a domain name.  
  - When a domain name is used, it is automatically resolved to an IP address. This is especially useful when working with Dynamic DNS (DDNS).  
- **Custom DNS resolution**:  
  - Use the `DNS` setting to resolve `PasvServerAddress` through a custom DNS server.  

## Demo configuration file

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
  "PrivateKeyFile": "privateKey.key",
  "ExecutingAssemblyVersion": "2.5.4.0",
  "TypeAssemblyQualifiedName": "Kaven.Standard.FtpServerConfig, Kaven.Standard, Version=2.5.4.0, Culture=neutral, PublicKeyToken=null",
  "CreatedAt": "2024-06-10T02:47:46.1686396Z",
  "LastModifiedAt": "2025-08-19T11:46:13.8211366Z"
}
```

## Docker

[kavenzero/ftp](https://hub.docker.com/r/kavenzero/ftp)

## Other

[.NET tool](https://www.nuget.org/packages/KCmd/#ftp-server)
