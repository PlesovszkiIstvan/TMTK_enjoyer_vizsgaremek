<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class TermekekUpdateChecker extends FormRequest
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
            'token' => 'required',
            'termek_id' => 'required|numeric',
            'termek_kateg' => 'required',
            'termek_nev' => 'required',
            'gyarto_id' => 'required|numeric',
            'raktarondb' => 'required|numeric',
            'tomeg_tulajdonsaga_id' => 'required|numeric',
            'tomeg_erteke' => 'required|numeric',
            'szine' => 'required',
            'leiras' => 'required',
            'egyseg_ar' => 'required|numeric',
            'elerheto' => 'required|numeric',
        ];
    }

    public function messages(){
        return[
            'token.required' => 'A token mező kitöltése kötelező.',
            'termek_id.required' => 'A termék azonosító mező kitöltése kötelező.',
            'termek_kateg.required' => 'A termék kategória mező kitöltése kötelező.',
            'termek_nev.required' => 'A termék név mező kitöltése kötelező.',
            'gyarto_id.required' => 'A gyártó azonosító mező kitöltése kötelező.',
            'raktarondb.required' => 'A raktárkészlet mező kitöltése kötelező.',
            'tomeg_tulajdonsaga_id.required' => 'A tömeg tulajdonság azonosító mező kitöltése kötelező.',
            'tomeg_erteke.required' => 'A tömeg érték mező kitöltése kötelező.',
            'szine.required' => 'A szín mező kitöltése kötelező.',
            'leiras.required' => 'A leírás mező kitöltése kötelező.',
            'egyseg_ar.required' => 'Az egységár mező kitöltése kötelező.',
            'elerheto.required' => 'Az elérhetőség mező kitöltése kötelező.',

            'termek_id.numeric' => 'A termék azonosító mező csak számot tartalmazhat.',
            'gyarto_id.numeric' => 'A gyártó azonosító mező csak számot tartalmazhat.',
            'raktarondb.numeric' => 'A raktárkészlet mező csak számot tartalmazhat.',
            'tomeg_tulajdonsaga_id.numeric' => 'A tömeg tulajdonság azonosító mező csak számot tartalmazhat.',
            'tomeg_erteke.numeric' => 'A tömeg érték mező csak számot tartalmazhat.',
            'egyseg_ar.numeric' => 'Az egységár mező csak számot tartalmazhat.',
            'elerheto.numeric' => 'Az elérhetőség mező csak számot tartalmazhat.',
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
