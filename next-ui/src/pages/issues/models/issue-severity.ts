export const IssueSeverity = {
  Minor: 'Minor',
  Medium: 'Medium',
  Critical: 'Critical',
} as const;

export type IssueSeverity = (typeof IssueSeverity)[keyof typeof IssueSeverity];

export function getIssueSeverities(): string[] {
  const values = Object.keys(IssueSeverity);
  return values;
}
