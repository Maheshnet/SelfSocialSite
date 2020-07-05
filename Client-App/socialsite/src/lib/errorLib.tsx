import * as Sentry from "@sentry/browser";

const isLocal = process.env.NODE_ENV === "development";

export function initSentry() {
  if (!isLocal) {
    return;
  }

  Sentry.init({ dsn: "https://4c27ba646ec846e0ab5758d7fa0fe043@o407788.ingest.sentry.io/5277455" });
}

export function logError(error: any, errorInfo ?:null) {
  if (!isLocal) {
    return;
  }

  Sentry.withScope((scope) => {
    errorInfo && scope.setExtras(errorInfo);
    Sentry.captureException(error);
    //throw new Error("Extended Test Error 23");
  });
}