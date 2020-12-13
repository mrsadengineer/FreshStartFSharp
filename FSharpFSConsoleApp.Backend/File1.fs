module File1

open Suave
open Suave.Operators
open Suave.Successful
open Suave.Filters
open Suave.Files
open Suave.Logging
open System.Threading
open System
open System.Diagnostics


//simple custom config AND custom app route path for '/'
let runWebAndListeningServer argv = 
    printfn "Hello World with Web and Listening Servers!"
    let cts = new CancellationTokenSource()
    let logger = Targets.create Verbose [||]
   // Define the port where you want to serve. We'll hardcode this for now.
    let port = 8080   
    let cfg = // create an app config with the port
    
          { defaultConfig with
              bindings = [ HttpBinding.createSimple HTTP "0.0.0.0" port]
              bufferSize = 2048
              maxOps     = 10000
              logger     = logger}
    
    let app =  // We'll define a single GET route at the / endpoint that returns "Hello World"
          choose
            [ GET >=> choose
                [ path "/" >=> request (fun _ -> OK "Hello World!")] // printfn "Hello World from F#!" 
            ]


//if executing on linux distribution
    let execute cmd args =

        use proc = new Process()
        
        proc.StartInfo.FileName         <- cmd
        proc.StartInfo.CreateNoWindow   <- true
        proc.StartInfo.RedirectStandardOutput <- true
        proc.StartInfo.UseShellExecute  <- false
        proc.StartInfo.Arguments        <- args
        proc.StartInfo.CreateNoWindow   <- true
        
        let _ = proc.Start()
        proc.WaitForExit()
        proc.StandardOutput.ReadToEnd()





    //// Now we start the server
    //startWebServer cfg app
    //let listening, server = startWebServerAsync cfg (choose [ GET >=> browseHome ])
    let listening, server = startWebServerAsync cfg (choose [ GET >=> (Successful.OK "Hello World! startwebswerver async") ])
    Async.Start(server, cts.Token)
    // wait for the server to start listening
    listening |> Async.RunSynchronously |> printfn "start stats: %A"

    printfn "Make requests now"
    Console.ReadKey true |> ignore
    ////kill the server
    cts.Cancel()
