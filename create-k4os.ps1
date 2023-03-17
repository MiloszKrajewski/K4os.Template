Param(
    [Parameter(Mandatory=$True,Position=1)]
    [string] $project
)

Push-Location $PSScriptRoot
& dotnet new K4os -n $project
Set-Location $project
& git init
& git add .
& git commit -m "initial commit"
& ./build
Pop-Location
