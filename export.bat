@echo off

SET "o=%1"
IF "%1"=="" SET "o=Export"
ECHO "Exporting packages to '.\%o%'"

CALL :Build "AsepriteImporter" "Source\Core\AsepriteImporter" %o%
CALL :Pack "AsepriteImporter" "Source\Core\AsepriteImporter" %o%

CALL :Build "AsepriteImporter.MG" "Source\MonoGame\AsepriteImporter.MG" %o%
CALL :Pack "AsepriteImporter.MG" "Source\MonoGame\AsepriteImporter.MG" %o%

ECHO "> [ DONE! ] Press any key to continue..."
PAUSE

CALL explorer.exe "%o%"
EXIT /B %ERRORLEVEL%

@REM 1: ProjName; 2: ProjDir; 3: OutputDir
:Build
ECHO "> [ BUILD ] Building project '%~1'..."
CALL dotnet build "%~2\%~1.csproj" --output "%~3\%~1\Lib"
ECHO "> [ DOCS ] Documenting project '%~1'..."
CALL xmldoc2md "%~3\%~1\Lib\%~1.dll" --output "%~3\%~1\Docs" --gitlab-wiki --back-button
EXIT /B 0

@REM 1: ProjName; 2: ProjDir; 3: OutputDir
:Pack
ECHO "> [ PACKN ] Packing project '%~1'..."
CALL dotnet pack "%~2\%~1.csproj" --output "%~3\%~1"
EXIT /B 0