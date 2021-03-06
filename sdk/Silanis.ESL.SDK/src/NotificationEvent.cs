using System;

namespace Silanis.ESL.SDK
{
    public enum NotificationEvent
    {
        PACKAGE_ACTIVATE,
        PACKAGE_COMPLETE,
        PACKAGE_EXPIRE,
        PACKAGE_OPT_OUT,
        PACKAGE_DECLINE,
        SIGNER_COMPLETE,
        DOCUMENT_SIGNED,
        ROLE_REASSIGN,
        PACKAGE_CREATE,
        PACKAGE_DEACTIVATE,
        PACKAGE_READY_FOR_COMPLETION,
        PACKAGE_TRASH,
        PACKAGE_RESTORE,
        PACKAGE_DELETE
    }
}

