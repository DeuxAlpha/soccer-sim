<template>
  <div class="flex flex-col justify-start items-start w-full">
    <template v-if="allowLocalFile">
      <form @submit="loadDataFromInputFile" class="flex flex-col justify-start items-start">
        <label for="inputFile">CSV File</label>
        <input id="inputFile" type="file" @input="onFileInput">
        <label for="continent">Continent</label>
        <input class="border" id="continent" type="text" v-model="continent">
        <label for="country">Country</label>
        <input class="border" id="division" type="text" v-model="country">
        <label for="division">Division</label>
        <input class="border" id="division" type="text" v-model="division">
        <div class="flex flex-row items-center">
          <label for="league">League</label>
          <input class="ml-2" id="league-as-division" type="checkbox" @input="onLeagueAsDivisionCheckClicked">
        </div>
        <input class="border" id="league" type="text" :disabled="leagueSameAsDivision" v-model="league">
        <button type="submit">Submit<span v-if="loading">ting...</span></button>
      </form>
    </template>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import Papa, {Parser, ParseResult, ParseStepResult} from 'papaparse';
import {ImportRequest} from "@/models/requests/ImportRequest";
import Axios from "axios";

@Component({
  name: 'LeagueImport'
})
export default class LeagueImport<T> extends Vue {
  inputFile?: File;
  loadedData: any[] = [];
  listView: any[] = [];
  allowLocalFile = true;
  csvUrl = '';
  loading = false;

  preppedData?: ImportRequest

  continent = '';
  country = '';
  division = '';
  league = '';
  leagueSameAsDivision = false;

  onLeagueAsDivisionCheckClicked() {
    this.leagueSameAsDivision = !this.leagueSameAsDivision;
    if (this.leagueSameAsDivision) this.league = this.division;
  }

  onFileInput(event) {
    const files = event.target.files;
    if (files.length <= 0) return;
    this.inputFile = files[0];
  }

  // async uploadLeague() {
  //   await fetch('https://localhost:5001/importers', {
  //     method: 'POST',
  //     body:
  //   })
  // }

  async loadDataFromInputFile() {
    if (!this.inputFile) return;
    Papa.parse(this.inputFile, {
      complete: results => {
        this.preppedData = {
          League: this.league,
          Division: this.division,
          Continent: this.continent,
          Country: this.country,
          Collection: results.data.map(d => {
            const s = d as any;
            return {
              HomeTeamName: s.HomeTeam,
              AwayTeamName: s.AwayTeam,
              HomeHalfTimeGoals: s.HTHG,
              AwayHalfTimeGoals: s.HTAG,
              HomeFullTimeGoals: s.FTHG,
              AwayFullTimeGoals: s.FTAG,
              Timestamp: s.Date
            }
          })
        }
        this.sendImportData();
      },
      header: true,
      skipEmptyLines: true
    })
  }

  async updateListView() {
    this.listView = this.loadedData;
    // doesn't do anything yet.
  }

  downloadURI(uri, name) {
    const link = document.createElement("a");
    link.download = name;
    link.href = uri;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }

  async sendImportData() {
    console.log('prepped data', this.preppedData);
    this.loading = true;
    await Axios.post('https://localhost:5001/importers', this.preppedData).finally(() => this.loading = false);
    // await fetch('https://localhost:5001/importers', {
    //   body: JSON.stringify(this.preppedData),
    //   method: 'POST',
    // })
  }

  async onLoadUrl() {
    // const url = this.csvUrl;
    // console.log('url', url);
    // if (!url) return;

    // Papa.parse(url, {
    //   download: true,
    //   step: (results: ParseStepResult<T>, parser: Parser) => {
    //     console.log('step');
    //     console.log('results', results);
    //     console.log('parser', parser);
    //   },
    //   complete: (results: ParseResult<T>, file: string) => {
    //     console.log('complete');
    //     console.log('results', results);
    //     console.log('file', file);
    //   },
    //   downloadRequestHeaders: {
    //     'Access-Control-Allow-Origin': '*',
    //     'Access-Control-Allow-Methods': 'POST, GET, OPTIONS, PUT, DELETE',
    //     'Access-Control-Allow-Headers': 'Origin, Content-Type, Accept, Authorization, X-Request-With'
    //   }
    // })
  }
}
</script>

<style scoped>

</style>
