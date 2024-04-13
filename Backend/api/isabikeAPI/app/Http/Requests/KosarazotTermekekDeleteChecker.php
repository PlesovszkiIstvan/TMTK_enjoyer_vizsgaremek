<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class KosarazotTermekekDeleteChecker extends FormRequest
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
            //'termek_id' => 'required|integer',
        ];
    }
    
    public function messages(){
        return[
            'termek_id.required' => 'A termék ID mező megadása kötelező.',
            'termek_id.integer' => 'A termék ID mezőnek integer típusúnak kell lennie.',
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
