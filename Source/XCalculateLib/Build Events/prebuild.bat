@ECHO OFF
SET SolutionDir=%~1
SET ProjectDir=%~2
SET CodeGeneratorExe=%SolutionDir%\CodeGenerator\CodeGenerator.exe
SET ReplacementFileName=Replacements.replace
SET GeneratedCodeDirName=Generated Code
SET GeneratedCodeDir=%ProjectDir%\%GeneratedCodeDirName%

SET ValuesCodeTemplateDir=%ProjectDir%\Code Templates\Values
SET ValuesReplacementFilePath=%ValuesCodeTemplateDir%\%ReplacementFileName%

SET UnitsCodeTemplateDir=%ProjectDir%\Code Templates\Units
SET UnitsReplacementFilePath=%UnitsCodeTemplateDir%\%ReplacementFileName%

@ECHO ON
del "%GeneratedCodeDir%\*" /q
"%CodeGeneratorExe%" "%ValuesCodeTemplateDir%\Value.template" "%ValuesReplacementFilePath%" "%GeneratedCodeDir%\${TypeName}Value.cs" -overwrite
"%CodeGeneratorExe%" "%ValuesCodeTemplateDir%\ValueArray.template" "%ValuesReplacementFilePath%" "%GeneratedCodeDir%\${TypeName}ValueArray.cs" -overwrite
"%CodeGeneratorExe%" "%UnitsCodeTemplateDir%\Unit.template" "%UnitsReplacementFilePath%" "%GeneratedCodeDir%\${ClassName}Unit.cs" -overwrite
