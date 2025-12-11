# Ajout d'un cache de session sous SQLServer :

Une fois la base de données republiée, il faut exécuter la commande : 
```dotnet sql-cache create "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoUser.Session;Integrated Security=True;Encrypt=True" dbo SessionCache```