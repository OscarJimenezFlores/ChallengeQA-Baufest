## BaufestTests Automation ##

Challenge empleando diversas tecnologías para la automatización BDD

---
1. clonar repositorio:

```bash
git clone https://github.com/OscarJimenezFlores/ChallengeQA-Baufest.git
```

---
2. restaurar estando dentro del proyecto (cd nombre_proyecto):

```bash
dotnet restore

```
---
3. Ejecutar la siguiente línea de comando para instalar y utilizar LivingDoc:

```bash
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
```

---
4. Ejecutar las pruebas, lo cual generará un archivo TestExecution.json, el cual contiene los resultados:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=..\Cobertura\
```

---
5. Se genera el reporte de ejecución de pruebas utilizando el archivo de resultados anteriormente mencionado y utilizando la libreria (DLL) generada por la compilación de las pruebas:

```bash
livingdoc test-assembly .\reto01.Tests\bin\Debug\net6.0\reto01.Tests.dll -t .\reto01.Tests\bin\Debug\net6.0\TestExecution.json -o reto01.html
```

```bash
livingdoc test-assembly .\reto02.Tests\bin\Debug\net6.0\reto02.Tests.dll -t .\reto02.Tests\bin\Debug\net6.0\TestExecution.json -o reto02.html
```
---
6. Finalmente podrá visualizar los resultados en los archivos reto01.html y reto02.html, ubicados en la raíz de la solución.

