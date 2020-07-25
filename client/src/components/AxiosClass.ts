import {AxiosStatic} from "axios";

export class AxiosClass {
  public static async MakeCall(axios: AxiosStatic) {
    await axios.get('https://localhost:5001/WeatherForecast').then(response => console.dir(response));
  }
}