<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;


class BearerTokenChecker extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return false;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [
            //
        ];
    }

    public function hasBearer($token){
        if (empty($token)) {
            $this->failedValidation("Bearer token megadása kötelezö");
        }
    }

    public function failedValidation($error){
        throw new HttpResponseException(response()->json([
            "success"=>false,
            "message"=>$error,
        ], 400));
    }
}
