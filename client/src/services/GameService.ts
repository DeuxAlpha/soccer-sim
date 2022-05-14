export class GameService {
  public static CreateRangeOfEvents(goals: number, minMinute: number, maxMinute: number, maxAddedMinutes: number): GameScoreEvent[] {
    let currentGoal = 0;
    const events: GameScoreEvent[] = [];
    while (currentGoal < goals) {
      const minute = this.randomInRange(minMinute, maxMinute)
      let addedMinute = 0;
      if (minute === maxMinute) {
        addedMinute = this.randomInRange(1, maxAddedMinutes);
      }
      const event: GameScoreEvent = {
        Minute: minute,
        OvertimeMinute: addedMinute
      }
      events.push(event);
      currentGoal ++;
    }
    return events;
  }

  private static randomInRange(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }
}
export type GameScoreEvent = {
  Minute: number;
  OvertimeMinute: number;
}
