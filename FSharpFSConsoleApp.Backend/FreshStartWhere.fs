module FreshStartWhere

open Suave
open Suave.Operators
open Suave.Successful
open Suave.Filters
open Suave.Files
open Suave.Logging
open System.Threading
open System
open System.Diagnostics

type TZInfo = {tzName: string; minDiff: float; localTime: string; utcOffset: float}
let getTZ6am () = 

    // This gets all the time zones into a List-like object
    let tzs = TimeZoneInfo.GetSystemTimeZones()
    Console.WriteLine(tzs)
    // List comprehension + type inference allows us to easily perform conversions
    let tzList = [
        for tz in tzs do
        // convert the current time to the local time zone
        let localTz = TimeZoneInfo.ConvertTime(DateTime.Now, tz) 
        // Get the datetime object if it was 5:00pm 
        let fivePM = DateTime(localTz.Year, localTz.Month, localTz.Day, 6, 0, 0)
        // Get the difference between now local time and 5:00pm local time.
        let minDifference = (localTz - fivePM).TotalMinutes
        yield {
                tzName=tz.StandardName;
                minDiff=minDifference;
                localTime=localTz.ToString("hh:mm tt");
                utcOffset=tz.BaseUtcOffset.TotalHours;
             }
    ]
    //printfn "%A" tzList.Head
    // We use the pipe operator to chain function calls together
    tzList 
        // filter so that we only get tz after 5pm
        |> List.filter (fun (i:TZInfo) -> i.minDiff >= 0.0) 
        // sort by minDiff
        |> List.sortBy (fun (i:TZInfo) -> i.minDiff) 
        // Get the first item
        |> List.head

    //Console.WriteLine(tzList.Head.tzName.ToString())

