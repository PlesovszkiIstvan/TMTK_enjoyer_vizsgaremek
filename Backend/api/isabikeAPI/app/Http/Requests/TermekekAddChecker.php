<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class TermekekAddChecker extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [
            "token"=>"required",
            "termek_kateg"=>"required",
            "termek_nev"=>"required",
            "gyarto_id"=>"required|numeric",
            "raktarondb"=>"required|numeric",
            "tomeg_tulajdonsaga_id"=>"required|numeric",
            "tomeg_erteke"=>"required|numeric",
            "szine"=>"required",
            "leiras"=>"required",
            "egyseg_ar"=>"required|numeric",
            "elerheto"=>"required"
        ];
    }
    
    public function messages(){
        return[
            "token.required"=>"token megadása kötelezö",
            "termek_kateg.required"=>"termék kategoria megadása kötelezö",
            "termek_nev.required"=>"termék név megadása kötelezö",
            "gyarto_id.required"=>"gyárto id megadása kötelezö",
            "raktarondb.required"=>"raktárondb megadása kötelezö",
            "tomeg_tulajdonsaga_id.required"=>"tomeg tulajdonsaga id megadása kötelezö",
            "tomeg_erteke.required"=>"tomeg erteke megadása kötelezö",
            "szine.required"=>"szine megadása kötelezö",
            "leiras.required"=>"leirás megadása kötelezö",
            "egyseg_ar.required"=>"egység ár megadása kötelezö",
            "elerheto.required"=>"elerheto megadása kötelezö",

            "gyarto_id.numeric"=>" csak szám lehet",
            "raktarondb.numeric"=>" csak szám lehet",
            "tomeg_tulajdonsaga_id.numeric"=>" csak szám lehet",
            "tomeg_erteke.numeric"=>" csak szám lehet",
            "egyseg_ar.numeric"=>" csak szám lehet",
            "elerheto.numeric"=>" csak szám lehet"
        ];
    }

    public function failedValidation(Validator $validator){
        throw new HttpResponseException(response()->json([
            "success"=>false,
            "message"=>"Adatbeviteli hiba",
            "data"=>$validator->errors()
        ], 405));
    }
}
