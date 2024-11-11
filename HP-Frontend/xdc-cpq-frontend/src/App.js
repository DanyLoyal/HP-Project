// src/App.js
import React from 'react';
import { Routes, Route } from 'react-router-dom';
import ProductList from './pages/ProductList';
import QuoteCreator from './pages/QuoteCreator';
import QuoteSummary from './pages/QuoteSummary';

const App = () => {
    return (
        <Routes>
        <Route path="/" element={<ProductList />} />
            <Route path="/quote-creator" element={<QuoteCreator />} />
            <Route path="/quote-summary" element={<QuoteSummary />} />
        </Routes>
    );
};

export default App;
