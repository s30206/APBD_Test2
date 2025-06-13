# Setting up `appsettings.json`

Create a file named `appsettings.json` inside the `src/APBD_Test2.API` folder with the following content:

<pre>
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "Database": ""
    }
}
</pre>

In the `Database` field, provide your connection string to the Microsoft SQL Server instance.