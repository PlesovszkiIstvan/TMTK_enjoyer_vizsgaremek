<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class KosarazotTermekekUpdateChecker extends FormRequest
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
            'token' => 'required|string',
            'termek_id' => 'required|integer',
            'darabszam' => 'required|integer|min:1',
        ];
    }

    public function messages(){
        return[
            'token.required' => 'A token mező megadása kötelező.',
            'token.string' => 'A token mezőnek string típusúnak kell lennie.',
            'termek_id.required' => 'A termék ID mező megadása kötelező.',
            'termek_id.integer' => 'A termék ID mezőnek integer típusúnak kell lennie.',
            'darabszam.required' => 'A darabszám mező megadása kötelező.',
            'darabszam.integer' => 'A darabszám mezőnek integer típusúnak kell lennie.',
            'darabszam.min' => 'A darabszám minimum értéke 1.',
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
