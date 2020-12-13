// Learn more about F# at http://fsharp.org

open System

// We'll use argv later :)

[<EntryPoint>]
let main argv =
    
    //########################################prototyping
    //allwebserverimplementations.runAsyncWCT argv
    //allwebserverimplementations.runWebServer argv
    //advanceexampwebserver.start() runAdvanceWebServer2
    //allwebserverimplementations.runAdvanceWebServer argv
    //allwebserverimplementations.runAdvanceWebServer2 argv
    //##############################################


    //working
    //File1.runWebAndListeningServer argv
    
    //working
    //-simple custom config
    //-async
    //listening server?
    //-prints out start stats 
    //File2.runWebServerCustomConfigSimpleHelloWOrldReturn argv //index on website/app returns "Hello World! startwebswerver async"
    


    //working
    //-simple custom config
    //-multiple paths for app/website
     ////single http operation - get http operation
    //-async
    //-listenting server?
    //-prints out start stats
    //-cancels after key pressed
    //File3.runWebServerWCustomConfigCustomRoutes argv
    


    //working
    //-config homeFolder for static files
     ////single http operation - get http operation
    //-async
    //-listenting server?
    //File4.runWebServerWCustomConfigCustomRoutesBrowsweHome argv




    //working 
    //-config homeFolder for static files
    //-retrieve static file
    //-async
    ////single http operation - get http operation
    //File5.runWebServerWCustomConfigStaticFilesFromBrowserHome argv



    //working 
    //-config homeFolder for static files
    //-retrieve static file //if files embedded don't forget to change propteries on the file to copy if newer.
    //-use both url and uri interchangable
    //-static pages are linking toeachother
    //-async
    //-explore a more complex app choosing structure. imbedded. 
    //-comunications between static pages
    //File6.runWebServerWCustomConfigStaticFilesFromBrowserHome argv

    
    //working 
    //-config homeFolder for static files
    //-retrieve static file
    //-use both url and uri interchangable
    //-static pages are linking toeachother
    //-async - benefit is that you can run two app async
    //-explore a more complex app choosing structure. imbedded. 
    //-comunications between static pages
    //-testing: post capabilities
    //multipe http operation
    //-get
    //-post
    //CORS configuration is required for post and other routing/http operations
    File7.runWebServerWCustomConfigStaticFilesFromBrowserHome argv

    0 // return an integer exit code
