SET SOURCE_DIR=%~1
SET TARGET_DIR=..\..\Source\XCalculate.Web.App\Calculators\
IF NOT EXIST "%TARGET_DIR%" (
   mkdir "%TARGET_DIR%"
)
xcopy "%SOURCE_DIR%" "%TARGET_DIR%" /y