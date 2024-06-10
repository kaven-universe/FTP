# [FTP](https://github.com/kaven-universe/FTP)

A dedicated FTP server designed for NAT users.

- Supports basic FTP commands (not fully supported)
- Partial support for explicit/implicit encryption
- Control connections support TLS encryption
- Data connections support TLS encryption only in passive mode
- `PasvServerAddress` supports setting IP or domain name. When set to domain name, it will automatically resolve to IP, which is very useful when using DDNS.

demo configuration file:

```json
{
  "Port": 21,
  "PasvServerAddress": "",
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
  "EnableTls": true,
  "CertificateFile": "certificate.crt",
  "PrivateKeyFile": "privateKey.key",
  "ExecutingAssemblyVersion": "2.3.9.0",
  "TypeAssemblyQualifiedName": "Kaven.Standard.Net.Ftp.Server.FtpServerConfig, Kaven.Standard, Version=2.3.9.0, Culture=neutral, PublicKeyToken=null",
  "CreatedAt": "2024-06-10T02:47:46.1686396Z",
  "LastModifiedAt": "2024-06-10T02:47:46.1686396Z"
}
```

## Docker

[kavenzero/ftp](https://hub.docker.com/r/kavenzero/ftp)

## Other

[.NET tool](https://www.nuget.org/packages/KCmd/#ftp-server)
