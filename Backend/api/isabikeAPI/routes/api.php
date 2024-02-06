<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\TermekContoller;
use App\Http\Controllers\GyartokController;

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

