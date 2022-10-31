## Pruebas: Reporte de ejecución BDD ##

---
1. clonar repositorio

```bash
git clone
```

2. restaurar

```bash
cd nombre_proyecto
dotnet restore
```


---
Adicionalmente para generar utilizaremos la herramienta LivingDoc mediante linea de comandos para eso instalamos la herramienta con el siguiente comando:

```bash
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
```

---
Ejecutamos las pruebas, lo cual generará un archivo TestExecution.json, el cual contiene los resultados de la ejecución de las pruebas:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=..\Cobertura\
```

---
Generamos el reporte de ejecución de pruebas utilizando el archivo de resultados anteriormente mencionado y utilizando la libreria (DLL) generada por la compilación de las pruebas:

```bash
livingdoc test-assembly .\reto01.Tests\bin\Debug\net6.0\reto01.Tests.dll -t .\reto01.Tests\bin\Debug\net6.0\TestExecution.json -o reto01.html
```

```bash
livingdoc test-assembly .\reto02.Tests\bin\Debug\net6.0\reto02.Tests.dll -t .\reto02.Tests\bin\Debug\net6.0\TestExecution.json -o reto02.html
```