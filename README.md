# financeAPI
## Setting
### Nuget
1. Microsoft.EntityFramework.Tools
2. Microsoft.EntityFramework.Design
3. Microsoft.EntityFramework.SqlServer

### Migration
```bash
$ dotnet ef migrations add init
$ dotnet ef database update
```

### appsettings.json
```json
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost,1433;Initial Catalog=finshark;User Id=sa;Password=xxxxxx;TrustServerCertificate=true"
  },
```