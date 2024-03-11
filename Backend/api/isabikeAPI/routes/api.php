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

Route::get("/termekek/{limit}", [ TermekContoller::class, "getTermekek"]);
Route::post("/addtermek", [ TermekContoller::class, "addTermek"]);
Route::patch("/updatetermek", [ TermekContoller::class, "updateTermek"]);
Route::delete("/deletetermek", [ TermekContoller::class, "deleteTermek"]);

Route::put("/updategyarto", [ GyartokController::class, "updateGyarto"]);
Route::post("/addgyarto", [ GyartokController::class, "addGyarto"]);
Route::get("/gyartok", [ GyartokController::class, "getGyartok"]);

Route::post("/registration", [ FelhasznaloController::class, "registerUser"]);
Route::put("/verify", [ FelhasznaloController::class, "verifyUser"]);
Route::post("/login", [ FelhasznaloController::class, "logIn"]);
Route::post("/logout", [ FelhasznaloController::class, "logOut"]);
Route::get("/getfelhasznalok", [ FelhasznaloController::class, "getFelhasznalok"]);
Route::put("/updatefelhasznalo", [ FelhasznaloController::class, "updateFelhasznalo"]);
Route::put("/updateonefelhasznalo", [ FelhasznaloController::class, "updateOneFelhasznalo"]);
Route::get("/getonefelhasznalo", [ FelhasznaloController::class, "getOneFelhasznalo"]);

Route::get("/ertekelesek", [ ErtekelesekController::class, "getErtekelesek"]);

Route::get("/tomegtulajdonsagok", [ TomegTulajdonsagokController::class, "getTomegTulajdonsagok"]);
Route::post("/addtomegtulajdonsagok", [ TomegTulajdonsagokController::class, "addTomegTulajdonsagok"]);

Route::get("/getvelemenyek", [ VelemenyekController::class, "getVelemenyek"]);
Route::post("/addvelemenyek", [ VelemenyekController::class, "addVelemenyek"]);
Route::delete("/deletevelemenyek", [ VelemenyekController::class, "deleteVelemenyek"]);

Route::post("/addtermekkep", [ TermekKepController::class, "addTermekKep"]);
Route::delete("/deletetermekkep", [ TermekKepController::class, "deleteTermekKep"]);

Route::get("/getonekosar", [ KosarazotTermekekController::class, "getOneKosar"]);
Route::post("/addkosar", [ KosarazotTermekekController::class, "addToKosar"]);
Route::put("/updatekosar", [ KosarazotTermekekController::class, "updateKosar"]);
Route::delete("/deletekosar", [ KosarazotTermekekController::class, "deleteKosar"]);

Route::post("/addrendeles", [RendelesekController::class, "addRendeles"]);
Route::get("/getallrendeles", [RendelesekController::class, "getAllRendeles"]);
Route::get("/getonerendeles", [RendelesekController::class, "getOneRendeles"]);
Route::get("/getallrendelttermek", [RendelesekController::class, "getAllRendeltTermek"]);
