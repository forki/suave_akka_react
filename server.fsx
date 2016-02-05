#I "./packages/Suave/lib/net40/"
#r "Suave.dll"
#load "app.fsx"

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors
open Suave.Sockets
open Suave.WebSocket
open System.Threading

open App

let cancellationTokenSource = new CancellationTokenSource()
let token = cancellationTokenSource.Token
let config = { defaultConfig with cancellationToken = token }

let _, server = startWebServerAsync config (app())
Async.Start(server, token)
printfn "Started"
//cancellationTokenSource.Cancel()
