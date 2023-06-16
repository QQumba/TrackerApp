import { Tag } from './tag';

export type Issue = {
  id: number;
  title: string;
  description: string;
  tags: Tag[];
};

export type IssueCreate = {
  title: string;
  description: string;
  tags: Tag[];
};
