namespace HP_Backend.wwwroot.css
/* site.css */

/* Reset & generelle basis styles (kan udvides som du vil) */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

/* Body - grundlæggende */
body {
    font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
background - color: #f8f9fa; /* Lys grå baggrund (kan ændres) */
    color: #333;              /* Standard tekstfarve */
    margin: 0;
}

/* Overskrifter */
h1, h2, h3, h4 {
    margin-bottom: 1rem;
color: #343a40; /* Mørkegrå */
    font - weight: 600;
}

h2 {
    font-size: 1.5rem;
}

/* Afstand mellem sektioner / containere */
.container {
    margin: 0 auto;
max - width: 1200px;
padding: 1rem;
}

/* Generel styling til afsnit eller sektion */
section {
    margin-bottom: 2rem;
}

/* Knappen .btn-smartquote */
.btn - smartquote {
display: inline - block;
    background - color: #28a745;
    color: #fff;
    padding: 0.5rem 1rem;
    border - radius: 0.4rem;
    text - decoration: none;
    font - weight: 500;
transition: background - color 0.2s ease-in-out;
border: none; /* Hvis du bruger <button> i stedet for <a> */
cursor: pointer;
}

/* Hover-effekt på knappen */
.btn - smartquote:hover {
    background-color: #218838;
}

/* Tabellen – generel opstilling */
table {
    width: 100 %;
border - collapse: collapse;
margin - bottom: 1.5rem;
background - color: #fff;
    border: 1px solid #dee2e6; /* Tynd ramme omkring selve tabellen */
    border-radius: 0.4rem;     /* Afrundede kanter */
overflow: hidden;          /* Skjuler skarpe hjørner på table, hvis border-radius */
}

/* Tabelhoved */
table thead
{
    background-color: #343a40; /* Mørkegrå */
    color: #fff;
}
table th
{
    padding: 0.75rem;
    text-align: left;
    font-weight: 600;
}

/* Tabelceller */
table td
{
    border-top: 1px solid #dee2e6;
    padding: 0.75rem;
}

/* Striped baggrund – hver anden række */
table tbody tr:nth - of - type(odd) {
    background - color: #f2f2f2;
}

/* Hover-effekt på rækker (valgfri) */
table tbody tr:hover {
    background-color: #e9ecef;
}

/* Input-felter i formularer */
input[type = "text"],
input[type = "email"],
input[type = "number"],
select {
    display: block;
width: 100 %;
max - width: 300px; /* Kan justeres */
padding: 0.4rem 0.6rem;
margin - bottom: 1rem;
border: 1px solid #ced4da;
    border-radius: 0.3rem;
font - size: 1rem;
}

/* Formular-knapper */
button {
    padding: 0.5rem 1rem;
border - radius: 0.3rem;
border: none;
background - color: #007bff;
    color: #fff;
    font - size: 1rem;
cursor: pointer;
transition: background - color 0.2s;
}

button: hover {
    background - color: #0069d9;
}

/* Hvis du vil have en "primary" og "secondary" knap */
.btn - primary {
    background - color: #007bff;
}
.btn - primary:hover {
    background-color: #0069d9;
}
.btn - secondary {
    background - color: #6c757d;
    color: #fff;
}
.btn - secondary:hover {
    background-color: #5a6268;
}

/* En simpel header & footer style (hvis du bruger dem i layout) */
header {
    margin-bottom: 1.5rem;
}
footer {
    margin-top: 2rem;
text - align: center;
font - size: 0.9rem;
color: #6c757d;
}
