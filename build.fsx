#load "build.imports.fsx"

open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.DotNet
open Fake.DotNet.Testing
open Fake.Core

// Properties
let buildDir = "./build/"
let testDir  = "./test/"

// Targets
Target.create "Clean" (fun _ ->
    Shell.cleanDirs [buildDir; testDir]
)

Target.create "BuildApp" (fun _ ->
   !! "src/app/**/*.csproj"
     |> MSBuild.runRelease id buildDir "Build"
     |> Trace.logItems "AppBuild-Output: "
)

Target.create "BuildTest" (fun _ ->
    !! "src/test/**/*.csproj"
      |> MSBuild.runDebug id testDir "Build"
      |> Trace.logItems "TestBuild-Output: "
)

Target.create "Test" (fun _ ->
    !! (testDir + "/NUnit.Test.*.dll")
      |> NUnit3.run (fun p ->
          {p with
                ShadowCopy = false })
)

Target.create "Default" (fun _ ->
    Trace.trace "Hello World from FAKE"
)

// Dependencies
open Fake.Core.TargetOperators
"Clean"
  ==> "BuildApp"
  ==> "BuildTest"
  ==> "Test"
  ==> "Default"

// start build
Target.runOrDefault "Default"





// #r "paket:
// nuget Fake.IO.FileSystem
// nuget Fake.Core.Target"

// #load "./.fake/build.fsx/intellisense.fsx"

// #load "build.tools.fsx"

// let clean () = !! "**/bin/" ++ "**/obj/" |> DeleteDirs
// let build () = Proj.build "src"
// let restore () = Proj.restore "src"
// let test () = Proj.testAll ()
// let release () = Proj.releaseNupkg ()

// Target "Clean" (fun _ -> clean ())

// Target "Restore" (fun _ -> restore ())

// Target "Build" (fun _ -> build ())

// Target "Rebuild" ignore

// Target "Release" (fun _ -> release ())

// Target "Test" (fun _ -> test ())

// Target "Release:Nuget" (fun _ ->
//     let apiKey = Proj.settings |> Config.valueOrFail "nuget" "accessKey"
//     Proj.publishNugetOrg apiKey "K4os.Template"
// )

// "Restore" ==> "Build"
// "Build" ==> "Rebuild"
// "Clean" ?=> "Restore"
// "Clean" ==> "Rebuild"
// "Rebuild" ==> "Release"
// "Test" ==> "Release"
// "Build" ?=> "Test"
// "Release" ==> "Release:Nuget"

// RunTargetOrDefault "Build"