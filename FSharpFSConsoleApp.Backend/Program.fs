// Learn more about F# at http://fsharp.org

open System

// We'll use argv later :)

[<EntryPoint>]
let main argv =
    
    //let success = File1.main argv

    //printf "%A" <| File1.main argv
 
    FreshStartWebServerApp.FreshStartWebServerApp argv
    0 // return an integer exit code
