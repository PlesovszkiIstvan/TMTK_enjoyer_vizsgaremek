<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class GyartokUpdateChecker extends FormRequest
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
            'token' => 'required|string|max:255',
            'gyarto_id' => 'required|numeric|min:1|max:999999999',
            'gyarto_neve' => 'required|string|max:255',
            'telefonszama' => 'required|string|max:255',
            'webhely' => 'required|string|max:255',
        ];
    }

    public function messages(){
        return[
            'token.required' => 'A token mező kitöltése kötelező.',
            'token.string' => 'A token mező csak szöveget tartalmazhat.',
            'token.max' => 'A token mező maximális hossza 255 karakter.',
            'gyarto_id.required' => 'A gyártó azonosító mező kitöltése kötelező.',
            'gyarto_id.numeric' => 'A gyártó azonosító mező csak számot tartalmazhat.',
            'gyarto_id.min' => 'A gyártó azonosító mező minimum értéke 1.',
            'gyarto_id.max' => 'A gyártó azonosító mező maximum értéke 999 999 999.',
            'gyarto_neve.required' => 'A gyártó neve mező kitöltése kötelező.',
            'gyarto_neve.string' => 'A gyártó neve mező csak szöveget tartalmazhat.',
            'gyarto_neve.max' => 'A gyártó neve mező maximális hossza 255 karakter.',
            'telefonszama.required' => 'A telefonszám mező kitöltése kötelező.',
            'telefonszama.string' => 'A telefonszám mező csak szöveget tartalmazhat.',
            'telefonszama.max' => 'A telefonszám mező maximális hossza 255 karakter.',
            'webhely.required' => 'A webhely mező kitöltése kötelező.',
            'webhely.string' => 'A webhely mező csak szöveget tartalmazhat.',
            'webhely.max' => 'A webhely mező maximális hossza 255 karakter.',
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
