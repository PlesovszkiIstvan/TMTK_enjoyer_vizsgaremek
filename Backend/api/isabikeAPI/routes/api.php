<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\TermekContoller;
use App\Http\Controllers\GyartokController;
use App\Http\Controllers\FelhasznaloController;

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

Route::get("/termekek", [ TermekContoller::class, "getTermekek"]);
Route::post("/addtermek", [ TermekContoller::class, "addTermek"]);
Route::patch("/updatetermek/{id}", [ TermekContoller::class, "updateTermek"]);
Route::delete("/deletetermek/{id}", [ TermekContoller::class, "deleteTermek"]);

Route::post("/addgyarto", [ GyartokController::class, "addGyarto"]);
Route::get("/gyartok", [ GyartokController::class, "getGyartok"]);

Route::post("/registration", [ FelhasznaloController::class, "registerUser"]);
Route::put("/verify", [ FelhasznaloController::class, "verifyUser"]);
Route::post("/login", [ FelhasznaloController::class, "logIn"]);
Route::post("/logout", [ FelhasznaloController::class, "logOut"]);
