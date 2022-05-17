export class GameService {
  public static CreateRangeOfEvents(goals: number, minMinute: number, maxMinute: number, maxAddedMinutes: number): GameScoreEvent[] {
    let currentGoal = 0;
    const events: GameScoreEvent[] = [];
    const usedMinutes: string[] = [];
    while (currentGoal < goals) {
      let minutes = this.getRandomMinute(minMinute, maxMinute, maxAddedMinutes);
      while (usedMinutes.includes(`${minutes.minute}${minutes.addedMinute}`)) { // If minutes already exist, get another
        minutes = this.getRandomMinute(minMinute, maxMinute, maxAddedMinutes);
      }
      const event: GameScoreEvent = {
        Minute: minutes.minute,
        OvertimeMinute: minutes.addedMinute
      }
      usedMinutes.push(`${minutes.minute}${minutes.addedMinute}`);
      events.push(event);
      currentGoal++;
    }
    return events;
  }

  private static getRandomMinute(
    minMinute: number,
    maxMinute: number,
    maxAddedMinutes: number):
    { minute: number, addedMinute: number } {
    const minute = this.randomInRange(minMinute, maxMinute)
    let addedMinute = 0;
    if (minute === maxMinute) {
      addedMinute = this.randomInRange(1, maxAddedMinutes);
    }
    return {
      minute, addedMinute
    }
  }

  private static randomInRange(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }
}

export type GameScoreEvent = {
  Minute: number;
  OvertimeMinute: number;
}
