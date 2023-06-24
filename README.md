# pruebaWeeClaims
Prueba practica para WeeClaims

Instrucciones:

- Crear tabla indicada en el script WCParticipantes.

- Actualizar cadena de conexión en el web.config segun se requiera:

<connectionStrings>
<add name="WeeCompanyEntities" connectionString="metadata=res://*/Models.db.csdl|res://*/Models.db.ssdl|res://*/Models.db.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=localhost;initial catalog=WeeCompany;user id=edgar1;password=1234;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>

Datos de ejempo en cadea de conexión que sedeben cambiar por los propios:

catalog=WeeCompany;  --Nombre de base de datos
user id=edgar1;      --Nombre de usuario
password=1234;       --Contraseña de usuario


- Al descargar solucion "Limpiar" y "recompilar"
