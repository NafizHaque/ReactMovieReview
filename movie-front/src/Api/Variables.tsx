const Variables ={
  API_URL:"https://localhost:7080/api/"
}

export const FetchMovies = () => {
  return fetch(Variables.API_URL+'movies')
    .then(response => response.json())
    .then(data=> data);
}

