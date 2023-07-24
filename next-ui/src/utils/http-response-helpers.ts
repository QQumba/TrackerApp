export function isResponseSuccessful(response: Response): boolean {
  return response.status >= 200 && response.status < 400;
}
