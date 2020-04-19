
## Entity Framework

### Adding a new migration

```bat
dotnet ef migrations add MigrationName --verbose --startup-project .\RandomUserApi
```

### Applying migration

```bat
dotnet ef database update --project ./RandomUserApi
```

### Update dotnet ef

```bat
dotnet tool update --global dotnet-ef
```
