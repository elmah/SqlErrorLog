@echo off
pushd "%~dp0"
call :main %*
popd
goto :EOF

:main
setlocal
nuget restore ^
 && (for %%v in (3.5 4.0 4.5) do for %%c in (Debug Release) do call msbuild "/p:Configuration=NETFX %%v %%c" /v:m %* || exit /b 1)
goto :EOF
