<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\TermekContoller;
use App\Http\Controllers\GyartokController;
use App\Http\Controllers\FelhasznaloController;
use App\Http\Controllers\ErtekelesekController;
use App\Http\Controllers\TomegTulajdonsagokController;
use App\Http\Controllers\VelemenyekController;
use App\Http\Controllers\TermekKepController;
use App\Http\Controllers\KosarazotTermekekController;
use App\Http\Controllers\RendelesekController;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "api" middleware group. Make something great!
|
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

Route::get("/termekek/{limit}", [ TermekContoller::class, "getTermekek"]); //web
Route::post("/addtermek", [ TermekContoller::class, "addTermek"]);
Route::patch("/updatetermek", [ TermekContoller::class, "updateTermek"]);
Route::delete("/deletetermek", [ TermekContoller::class, "deleteTermek"]);
Route::get("/onetermekek/{id}", [ TermekContoller::class, "getOneTermekek"]); //web

Route::get("/kategoriak", [ TermekContoller::class, "getKategoriak"]); //web


Route::put("/updategyarto", [ GyartokController::class, "updateGyarto"]);
Route::post("/addgyarto", [ GyartokController::class, "addGyarto"]);
Route::get("/gyartok", [ GyartokController::class, "getGyartok"]); //web

Route::post("/registration", [ FelhasznaloController::class, "registerUser"]); //web
Route::put("/verify", [ FelhasznaloController::class, "verifyUser"]); //web
Route::post("/login", [ FelhasznaloController::class, "logIn"]); //web
Route::post("/logout", [ FelhasznaloController::class, "logOut"]); //web
Route::get("/getfelhasznalok", [ FelhasznaloController::class, "getFelhasznalok"]);
Route::put("/updatefelhasznalo", [ FelhasznaloController::class, "updateFelhasznalo"]);
Route::put("/updateonefelhasznalo", [ FelhasznaloController::class, "updateOneFelhasznalo"]); //web
Route::get("/getonefelhasznalo", [ FelhasznaloController::class, "getOneFelhasznalo"]); //web

Route::get("/ertekelesek", [ ErtekelesekController::class, "getErtekelesek"]); //web

Route::get("/tomegtulajdonsagok", [ TomegTulajdonsagokController::class, "getTomegTulajdonsagok"]); //web
Route::post("/addtomegtulajdonsagok", [ TomegTulajdonsagokController::class, "addTomegTulajdonsagok"]);

Route::get("/getvelemenyek", [ VelemenyekController::class, "getVelemenyek"]); //web
Route::post("/addvelemenyek", [ VelemenyekController::class, "addVelemenyek"]); //web 
Route::delete("/deletevelemenyek", [ VelemenyekController::class, "deleteVelemenyek"]);

Route::post("/addtermekkep", [ TermekKepController::class, "addTermekKep"]);
Route::delete("/deletetermekkep", [ TermekKepController::class, "deleteTermekKep"]);
Route::get("/onetermekkepek/{termekid}", [ TermekKepController::class, "getOneTermekKepek"]); //web 

Route::get("/getonekosar", [ KosarazotTermekekController::class, "getOneKosar"]); //web 
Route::post("/addkosar", [ KosarazotTermekekController::class, "addToKosar"]); //web 
Route::put("/updatekosar", [ KosarazotTermekekController::class, "updateKosar"]); //web 
Route::delete("/deletekosar", [ KosarazotTermekekController::class, "deleteKosar"]); //web

Route::post("/addrendeles", [RendelesekController::class, "addRendeles"]); //web 
Route::get("/getallrendeles", [RendelesekController::class, "getAllRendeles"]);
Route::get("/getonerendeles", [RendelesekController::class, "getOneRendeles"]); //web
Route::get("/getallrendelttermek", [RendelesekController::class, "getAllRendeltTermek"]); 
