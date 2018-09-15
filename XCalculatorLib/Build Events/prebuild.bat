@ECHO OFF
SET SolutionDir=%~1
SET ProjectDir=%~2
SET CodeGeneratorExe=%SolutionDir%\CodeGenerator\CodeGenerator.exe
SET CodeTemplateDir=%ProjectDir%\Code Templates
SET ReplacementFileName=Replacements.replace
SET ReplacementFilePath=%CodeTemplateDir%\%ReplacementFileName%
SET GeneratedCodeDirName=Generated Code
SET GeneratedCodeDir=%ProjectDir%\%GeneratedCodeDirName%
@ECHO ON
del "%GeneratedCodeDir%\*" /q
"%CodeGeneratorExe%" "%CodeTemplateDir%\Value.template" "%ReplacementFilePath%" "%GeneratedCodeDir%\${TypeName}Value.cs" -overwrite
"%CodeGeneratorExe%" "%CodeTemplateDir%\ValueInfo.template" "%ReplacementFilePath%" "%GeneratedCodeDir%\${TypeName}ValueInfo.cs" -overwrite
"%CodeGeneratorExe%" "%CodeTemplateDir%\ValueArray.template" "%ReplacementFilePath%" "%GeneratedCodeDir%\${TypeName}ValueArray.cs" -overwrite
"%CodeGeneratorExe%" "%CodeTemplateDir%\ValueArrayInfo.template" "%ReplacementFilePath%" "%GeneratedCodeDir%\${TypeName}ValueArrayInfo.cs" -overwrite
