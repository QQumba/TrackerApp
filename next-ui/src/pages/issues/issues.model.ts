export interface Issue {
  id: number;
  title: string;
  description: string;
}

export interface IssueCreate {
  title: string;
  description: string;
}
