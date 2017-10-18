@echo off
pushd "%~dp0"
call :main %*
popd
goto :EOF

:main
setlocal
for %%i in (NuGet.exe) do set nuget=%%~dpnx$PATH:i
if "%nuget%"=="" goto :nonuget
if not exist dist md dist || exit /b 1
set VERSION_SUFFIX=
if not "%~1"=="" set VERSION_SUFFIX=-Properties "VersionSuffix=-%~1"
call build && for %%i in (*.nuspec) do (NuGet pack %%i %VERSION_SUFFIX% -Symbols -OutputDirectory dist || exit /b 1)
goto :EOF

:nonuget
echo NuGet executable not found in PATH
echo For more on NuGet, see http://nuget.codeplex.com
exit /b 2
