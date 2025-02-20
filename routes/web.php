<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\ProductController;

Route::get('/products/theme/{theme}', [ProductController::class, 'showProductsByTheme']);

