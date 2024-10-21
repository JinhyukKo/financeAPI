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
```
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost,1433;Initial Catalog=finshark;User Id=sa;Password=xxxxxx;TrustServerCertificate=true"
  }
```
MacOS +Docker

it depends on your setting.

## Progress

1. Stock.cs Comment.cs
2. AppDbContext.cs
3. Program.cs : AddDbContext
4. appsettings.json : ConnectionStrings
5. migration + dummy data
6. Controller
7. Program.cs : AddControllers MapControllers
while(post,delete,put)
8. DTOs
9. Mapper
10. Controller from sending model -> sending Dto


