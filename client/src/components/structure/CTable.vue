<template>
  <div v-if="table !== null" class="flex flex-col">
    <div class="flex flex-row">
      <span class="position">P</span>
      <span class="prev-position">pP</span>
      <span class="team-column">Team</span>
      <span class="games">G</span>
      <span class="wins">W</span>
      <span class="draws">D</span>
      <span class="losses">L</span>
      <span class="goals-for">GF</span>
      <span class="goals-against">GA</span>
      <span class="goal-diff">GD</span>
      <span class="points">Pts.</span>
    </div>
    <div class="flex flex-row" v-for="position of table.positions">
      <span class="position">{{ position.position }}</span>
      <span class="prev-position">{{ getPreviousPosition(position.teamName) }}</span>
      <span class="team-column">
        <span class="flex flex-row justify-start items-baseline">
          <span>{{ position.teamName }}</span>
          <span class="ml-2 text-xs">{{ position.attackStrength.toFixed(1) }}</span>
          <button @click="overrideInferredTeamStrength(position.teamName, position.inferredStrength)"
                class="ml-2 text-xs text-gray-600 hover:text-gray-700"
                v-if="position.inferredStrength">
            {{ position.inferredStrength.toFixed(1) }}
          </button>
        </span>
      </span>
      <span class="games">{{ position.games }}</span>
      <span class="wins">{{ position.wins }}</span>
      <span class="draws">{{ position.draws }}</span>
      <span class="losses">{{ position.losses }}</span>
      <span class="goals-for">{{ position.goalsFor }}</span>
      <span class="goals-against">{{ position.goalsAgainst }}</span>
      <span class="goal-diff">{{ position.goalDifference }}</span>
      <span class="points">{{ position.points }}</span>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop} from 'vue-property-decorator';
import {LeagueTable} from "@/models/LeagueTable";

@Component
export default class CTable extends Vue {
  @Prop([Object]) readonly table!: LeagueTable;
  @Prop(String) readonly season!: string;
  @Prop(String) readonly league!: string;

  getPreviousPosition(teamName: string): number {
    return this.table.previousPositions.find(p => p.teamName == teamName)!.position;
  }

  async overrideInferredTeamStrength(teamName: string, inferredStrength: number) {
    await this.axios.put(`teams/${teamName}/${this.season}/strengths/${inferredStrength}`);
  }
}
</script>

<style scoped lang="scss">
.position {
  width: 40px;
}

.prev-position {
  width: 40px;
}

.team-column {
  width: 300px;
}

.games {
  width: 40px;
}

.wins {
  width: 40px;
}

.draws {
  width: 40px;
}

.losses {
  width: 40px;
}

.goals-for {
  width: 40px;
}

.goals-against {
  width: 40px
}

.goal-diff {
  width: 40px;
}

.points {
  width: 40px;
}
</style>
