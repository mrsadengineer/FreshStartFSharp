namespace App1

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open System.Net
open Newtonsoft.Json

type Resources = FreshStart.Resource

type TZInfo = 
    {
        tzName:string
        localTime: string
    }

[<Activity (Label = "Fresh Start", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit Activity ()

    let mutable count:int = 1

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resources.Layout.Main)

        // Get our button from the layout resource, and attach an event to it
        let button = this.FindViewById<Button>(Resources.Id.myButton)
        let txtView = this.FindViewById<TextView>(Resources.Id.textView1);
        
        
        button.Click.Add (fun args -> 
            //button.Text <- sprintf "%d clicks!" count
            //count <- count + 1
            let webClient = new WebClient()
           
            //let tzi = JsonConvert.DeserializeObject<TZInfo>(webClient.DownloadString("https://fivepm.azurewebsites.net/"))
            let tzi = JsonConvert.DeserializeObject<TZInfo>(webClient.DownloadString("http://127.0.0.1:8080/"))
           
            //txtView.Text <- webClient.DownloadString("http://127.0.0.1:8080/")
            txtView.Text <- sprintf "It's (about) 5PM in the\n\n%s Timezone! \n\nSpecifically, it is %s there" tzi.tzName tzi.localTime


        )

