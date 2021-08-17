import Axios from 'axios';
import { Continent } from '../models/Continent';

export class SoccerSimApi {
  private readonly api = Axios.create({
    baseURL: 'https://localhost:5001'
  })

  public async GetContinents(queryRequest: QueryRequest): Promise<Continent> {
    await this.api.get('/api/continents', {
      data: {

      }
    })
  }
}