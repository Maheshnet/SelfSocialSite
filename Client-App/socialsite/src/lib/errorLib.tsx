import * as Sentry from "@sentry/browser";

const isLocal = process.env.NODE_ENV === "development";

export function initSentry() {
  if (!isLocal) {
    return;
  }

  Sentry.init({ dsn: "https://b3ea36055dcf4b79bc7ee046fd224ec5@o407788.ingest.sentry.io/5277439" });
}

export function logError(error: any, errorInfo ?:null) {
  if (!isLocal) {
    return;
  }

  Sentry.withScope((scope) => {
    errorInfo && scope.setExtras(errorInfo);
    Sentry.captureException(error);
    throw new Error("Extended Test Error 23");
  });
}