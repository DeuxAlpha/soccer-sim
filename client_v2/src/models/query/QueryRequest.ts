export type QueryRequest = {
  Filters?: Filter[];
  Sorters?: Sorter[];
  Aggregators?: Aggregator[];
  Distinctors?: Distinctor[];
  Page?: number;
  Items?: number;
}

export type Filter = {
  PropertyName: string;
  Value: string;
  Comparison: Comparison;
  Relation?: Relation;
}

export type Comparison =
  'Equal'
  | 'NotEqual'
  | 'LessThan'
  | 'LessThanOrEqual'
  | 'GreaterThan'
  | 'GreaterThanOrEqual'
  | 'Contains'
  | 'StartsWith'
  | 'EndsWith'
  | 'HasValue'
  | 'HasNoValue';

export type Relation = 'And' | 'AndAlso' | 'Or' | 'OrElse' | 'Xor';

export type Sorter = {

}