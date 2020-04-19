
## Entity Framework

### Adding a new migration

```bat
dotnet ef migrations add MigrationName --verbose --project .\Data --startup-project .\RandomUserApi
```

### Applying migration

```bat
dotnet ef database update --project .\Data --startup-project .\RandomUserApi
```

### Update dotnet ef

```bat
dotnet tool update --global dotnet-ef
```
