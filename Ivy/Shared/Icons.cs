namespace Ivy.Shared;

public static class IconsHelper
{
    public static Icons? FromString(string? iconName)
    {
        if (string.IsNullOrEmpty(iconName)) return null;
        if (Enum.TryParse(typeof(Icons), iconName, true, out var icon))
        {
            return (Icons)icon;
        }
        return null;
    }
}

public enum Icons
{
    None,

    // Extras:
    Google, //<FaGoogle />
    Azure,  //<VscAzure />
    Amazon, //<FaAmazon />
    Microsoft, //<FaMicrosoft />
    //Gitlab, //<FaGitlab />
    Bitbucket, //<FaBitbucket />
    Discord, //<FaDiscord />
    //Twitter, //<FaTwitter />
    //Instagram, //<FaInstagram />
    //Facebook, //<FaFacebook />
    //Linkedin, //<FaLinkedin />
    //Youtube, //<FaYoutube />
    Vimeo, //<FaVimeo />
    //Slack, //<FaSlack />
    Spotify, //<FaSpotify />
    Notion, //<FaNotion />
            //Apple, //<FaApple />
            //Github, //<FaGithub />

    // Lucide Icons:
    AArrowDown,
    AArrowUp,
    ALargeSmall,
    Accessibility,
    Activity,
    AirVent,
    Airplay,
    AlarmClock,
    AlarmClockCheck,
    AlarmClockMinus,
    AlarmClockOff,
    AlarmClockPlus,
    AlarmSmoke,
    Album,
    AlignCenter,
    AlignCenterHorizontal,
    AlignCenterVertical,
    AlignEndHorizontal,
    AlignEndVertical,
    AlignHorizontalDistributeCenter,
    AlignHorizontalDistributeEnd,
    AlignHorizontalDistributeStart,
    AlignHorizontalJustifyCenter,
    AlignHorizontalJustifyEnd,
    AlignHorizontalJustifyStart,
    AlignHorizontalSpaceAround,
    AlignHorizontalSpaceBetween,
    AlignJustify,
    AlignLeft,
    AlignRight,
    AlignStartHorizontal,
    AlignStartVertical,
    AlignVerticalDistributeCenter,
    AlignVerticalDistributeEnd,
    AlignVerticalDistributeStart,
    AlignVerticalJustifyCenter,
    AlignVerticalJustifyEnd,
    AlignVerticalJustifyStart,
    AlignVerticalSpaceAround,
    AlignVerticalSpaceBetween,
    Ambulance,
    Ampersand,
    Ampersands,
    Amphora,
    Anchor,
    Angry,
    Annoyed,
    Antenna,
    Anvil,
    Aperture,
    AppWindow,
    AppWindowMac,
    Apple,
    Archive,
    ArchiveRestore,
    ArchiveX,
    Armchair,
    ArrowBigDown,
    ArrowBigDownDash,
    ArrowBigLeft,
    ArrowBigLeftDash,
    ArrowBigRight,
    ArrowBigRightDash,
    ArrowBigUp,
    ArrowBigUpDash,
    ArrowDown,
    ArrowDown01,
    ArrowDown10,
    ArrowDownAZ,
    ArrowDownFromLine,
    ArrowDownLeft,
    ArrowDownNarrowWide,
    ArrowDownRight,
    ArrowDownToDot,
    ArrowDownToLine,
    ArrowDownUp,
    ArrowDownWideNarrow,
    ArrowDownZA,
    ArrowLeft,
    ArrowLeftFromLine,
    ArrowLeftRight,
    ArrowLeftToLine,
    ArrowRight,
    ArrowRightFromLine,
    ArrowRightLeft,
    ArrowRightToLine,
    ArrowUp,
    ArrowUp01,
    ArrowUp10,
    ArrowUpAZ,
    ArrowUpDown,
    ArrowUpFromDot,
    ArrowUpFromLine,
    ArrowUpLeft,
    ArrowUpNarrowWide,
    ArrowUpRight,
    ArrowUpToLine,
    ArrowUpWideNarrow,
    ArrowUpZA,
    ArrowsUpFromLine,
    Asterisk,
    AtSign,
    Atom,
    AudioLines,
    AudioWaveform,
    Award,
    Axe,
    Axis3d,
    Baby,
    Backpack,
    Badge,
    BadgeAlert,
    BadgeCent,
    BadgeCheck,
    BadgeDollarSign,
    BadgeEuro,
    BadgeHelp,
    BadgeIndianRupee,
    BadgeInfo,
    BadgeJapaneseYen,
    BadgeMinus,
    BadgePercent,
    BadgePlus,
    BadgePoundSterling,
    BadgeRussianRuble,
    BadgeSwissFranc,
    BadgeX,
    BaggageClaim,
    Ban,
    Banana,
    Bandage,
    Banknote,
    Barcode,
    Baseline,
    Bath,
    Battery,
    BatteryCharging,
    BatteryFull,
    BatteryLow,
    BatteryMedium,
    BatteryWarning,
    Beaker,
    Bean,
    BeanOff,
    Bed,
    BedDouble,
    BedSingle,
    Beef,
    Beer,
    BeerOff,
    Bell,
    BellDot,
    BellElectric,
    BellMinus,
    BellOff,
    BellPlus,
    BellRing,
    BetweenHorizontalEnd,
    BetweenHorizontalStart,
    BetweenVerticalEnd,
    BetweenVerticalStart,
    BicepsFlexed,
    Bike,
    Binary,
    Binoculars,
    Biohazard,
    Bird,
    Bitcoin,
    Blend,
    Blinds,
    Blocks,
    Bluetooth,
    BluetoothConnected,
    BluetoothOff,
    BluetoothSearching,
    Bold,
    Bolt,
    Bomb,
    Bone,
    Book,
    BookA,
    BookAudio,
    BookCheck,
    BookCopy,
    BookDashed,
    BookDown,
    BookHeadphones,
    BookHeart,
    BookImage,
    BookKey,
    BookLock,
    BookMarked,
    BookMinus,
    BookOpen,
    BookOpenCheck,
    BookOpenText,
    BookPlus,
    BookText,
    BookType,
    BookUp,
    BookUp2,
    BookUser,
    BookX,
    Bookmark,
    BookmarkCheck,
    BookmarkMinus,
    BookmarkPlus,
    BookmarkX,
    BoomBox,
    Bot,
    BotMessageSquare,
    BotOff,
    Box,
    Boxes,
    Braces,
    Brackets,
    Brain,
    BrainCircuit,
    BrainCog,
    BrickWall,
    Briefcase,
    BriefcaseBusiness,
    BriefcaseConveyorBelt,
    BriefcaseMedical,
    BringToFront,
    Brush,
    Bug,
    BugOff,
    BugPlay,
    Building,
    Building2,
    Bus,
    BusFront,
    Cable,
    CableCar,
    Cake,
    CakeSlice,
    Calculator,
    Calendar,
    Calendar1,
    CalendarArrowDown,
    CalendarArrowUp,
    CalendarCheck,
    CalendarCheck2,
    CalendarClock,
    CalendarCog,
    CalendarDays,
    CalendarFold,
    CalendarHeart,
    CalendarMinus,
    CalendarMinus2,
    CalendarOff,
    CalendarPlus,
    CalendarPlus2,
    CalendarRange,
    CalendarSearch,
    CalendarSync,
    CalendarX,
    CalendarX2,
    Camera,
    CameraOff,
    Candy,
    CandyCane,
    CandyOff,
    Cannabis,
    Captions,
    CaptionsOff,
    Car,
    CarFront,
    CarTaxiFront,
    Caravan,
    Carrot,
    CaseLower,
    CaseSensitive,
    CaseUpper,
    CassetteTape,
    Cast,
    Castle,
    Cat,
    Cctv,
    ChartArea,
    ChartBar,
    ChartBarBig,
    ChartBarDecreasing,
    ChartBarIncreasing,
    ChartBarStacked,
    ChartCandlestick,
    ChartColumn,
    ChartColumnBig,
    ChartColumnDecreasing,
    ChartColumnIncreasing,
    ChartColumnStacked,
    ChartGantt,
    ChartLine,
    ChartNetwork,
    ChartNoAxesColumn,
    ChartNoAxesColumnDecreasing,
    ChartNoAxesColumnIncreasing,
    ChartNoAxesCombined,
    ChartNoAxesGantt,
    ChartPie,
    ChartScatter,
    ChartSpline,
    Check,
    CheckCheck,
    ChefHat,
    Cherry,
    ChevronDown,
    ChevronFirst,
    ChevronLast,
    ChevronLeft,
    ChevronRight,
    ChevronUp,
    ChevronsDown,
    ChevronsDownUp,
    ChevronsLeft,
    ChevronsLeftRight,
    ChevronsLeftRightEllipsis,
    ChevronsRight,
    ChevronsRightLeft,
    ChevronsUp,
    ChevronsUpDown,
    Chrome,
    Church,
    Cigarette,
    CigaretteOff,
    Circle,
    CircleAlert,
    CircleArrowDown,
    CircleArrowLeft,
    CircleArrowOutDownLeft,
    CircleArrowOutDownRight,
    CircleArrowOutUpLeft,
    CircleArrowOutUpRight,
    CircleArrowRight,
    CircleArrowUp,
    CircleCheck,
    CircleCheckBig,
    CircleChevronDown,
    CircleChevronLeft,
    CircleChevronRight,
    CircleChevronUp,
    CircleDashed,
    CircleDivide,
    CircleDollarSign,
    CircleDot,
    CircleDotDashed,
    CircleEllipsis,
    CircleEqual,
    CircleFadingArrowUp,
    CircleFadingPlus,
    CircleGauge,
    CircleHelp,
    CircleMinus,
    CircleOff,
    CircleParking,
    CircleParkingOff,
    CirclePause,
    CirclePercent,
    CirclePlay,
    CirclePlus,
    CirclePower,
    CircleSlash,
    CircleSlash2,
    CircleStop,
    CircleUser,
    CircleUserRound,
    CircleX,
    CircuitBoard,
    Citrus,
    Clapperboard,
    Clipboard,
    ClipboardCheck,
    ClipboardCopy,
    ClipboardList,
    ClipboardMinus,
    ClipboardPaste,
    ClipboardPen,
    ClipboardPenLine,
    ClipboardPlus,
    ClipboardType,
    ClipboardX,
    Clock,
    Clock1,
    Clock10,
    Clock11,
    Clock12,
    Clock2,
    Clock3,
    Clock4,
    Clock5,
    Clock6,
    Clock7,
    Clock8,
    Clock9,
    ClockAlert,
    ClockArrowDown,
    ClockArrowUp,
    Cloud,
    CloudAlert,
    CloudCog,
    CloudDownload,
    CloudDrizzle,
    CloudFog,
    CloudHail,
    CloudLightning,
    CloudMoon,
    CloudMoonRain,
    CloudOff,
    CloudRain,
    CloudRainWind,
    CloudSnow,
    CloudSun,
    CloudSunRain,
    CloudUpload,
    Cloudy,
    Clover,
    Club,
    Code,
    CodeXml,
    Codepen,
    Codesandbox,
    Coffee,
    Cog,
    Coins,
    Columns2,
    Columns3,
    Columns4,
    Combine,
    Command,
    Compass,
    Component,
    Computer,
    ConciergeBell,
    Cone,
    Construction,
    Contact,
    ContactRound,
    Container,
    Contrast,
    Cookie,
    CookingPot,
    Copy,
    CopyCheck,
    CopyMinus,
    CopyPlus,
    CopySlash,
    CopyX,
    Copyleft,
    Copyright,
    CornerDownLeft,
    CornerDownRight,
    CornerLeftDown,
    CornerLeftUp,
    CornerRightDown,
    CornerRightUp,
    CornerUpLeft,
    CornerUpRight,
    Cpu,
    CreativeCommons,
    CreditCard,
    Croissant,
    Crop,
    Cross,
    Crosshair,
    Crown,
    Cuboid,
    CupSoda,
    Currency,
    Cylinder,
    Dam,
    Database,
    DatabaseBackup,
    DatabaseZap,
    Delete,
    Dessert,
    Diameter,
    Diamond,
    DiamondMinus,
    DiamondPercent,
    DiamondPlus,
    Dice1,
    Dice2,
    Dice3,
    Dice4,
    Dice5,
    Dice6,
    Dices,
    Diff,
    Disc,
    Disc2,
    Disc3,
    DiscAlbum,
    Divide,
    Dna,
    DnaOff,
    Dock,
    Dog,
    DollarSign,
    Donut,
    DoorClosed,
    DoorOpen,
    Dot,
    Download,
    DraftingCompass,
    Drama,
    Dribbble,
    Drill,
    Droplet,
    Droplets,
    Drum,
    Drumstick,
    Dumbbell,
    Ear,
    EarOff,
    Earth,
    EarthLock,
    Eclipse,
    Egg,
    EggFried,
    EggOff,
    Ellipsis,
    EllipsisVertical,
    Equal,
    EqualApproximately,
    EqualNot,
    Eraser,
    EthernetPort,
    Euro,
    Expand,
    ExternalLink,
    Eye,
    EyeClosed,
    EyeOff,
    Facebook,
    Factory,
    Fan,
    FastForward,
    Feather,
    Fence,
    FerrisWheel,
    Figma,
    File,
    FileArchive,
    FileAudio,
    FileAudio2,
    FileAxis3d,
    FileBadge,
    FileBadge2,
    FileBox,
    FileChartColumn,
    FileChartColumnIncreasing,
    FileChartLine,
    FileChartPie,
    FileCheck,
    FileCheck2,
    FileClock,
    FileCode,
    FileCode2,
    FileCog,
    FileDiff,
    FileDigit,
    FileDown,
    FileHeart,
    FileImage,
    FileInput,
    FileJson,
    FileJson2,
    FileKey,
    FileKey2,
    FileLock,
    FileLock2,
    FileMinus,
    FileMinus2,
    FileMusic,
    FileOutput,
    FilePen,
    FilePenLine,
    FilePlus,
    FilePlus2,
    FileQuestion,
    FileScan,
    FileSearch,
    FileSearch2,
    FileSliders,
    FileSpreadsheet,
    FileStack,
    FileSymlink,
    FileTerminal,
    FileText,
    FileType,
    FileType2,
    FileUp,
    FileUser,
    FileVideo,
    FileVideo2,
    FileVolume,
    FileVolume2,
    FileWarning,
    FileX,
    FileX2,
    Files,
    Film,
    Filter,
    FilterX,
    Fingerprint,
    FireExtinguisher,
    Fish,
    FishOff,
    FishSymbol,
    Flag,
    FlagOff,
    FlagTriangleLeft,
    FlagTriangleRight,
    Flame,
    FlameKindling,
    Flashlight,
    FlashlightOff,
    FlaskConical,
    FlaskConicalOff,
    FlaskRound,
    FlipHorizontal,
    FlipHorizontal2,
    FlipVertical,
    FlipVertical2,
    Flower,
    Flower2,
    Focus,
    FoldHorizontal,
    FoldVertical,
    Folder,
    FolderArchive,
    FolderCheck,
    FolderClock,
    FolderClosed,
    FolderCode,
    FolderCog,
    FolderDot,
    FolderDown,
    FolderGit,
    FolderGit2,
    FolderHeart,
    FolderInput,
    FolderKanban,
    FolderKey,
    FolderLock,
    FolderMinus,
    FolderOpen,
    FolderOpenDot,
    FolderOutput,
    FolderPen,
    FolderPlus,
    FolderRoot,
    FolderSearch,
    FolderSearch2,
    FolderSymlink,
    FolderSync,
    FolderTree,
    FolderUp,
    FolderX,
    Folders,
    Footprints,
    Forklift,
    Forward,
    Frame,
    Framer,
    Frown,
    Fuel,
    Fullscreen,
    GalleryHorizontal,
    GalleryHorizontalEnd,
    GalleryThumbnails,
    GalleryVertical,
    GalleryVerticalEnd,
    Gamepad,
    Gamepad2,
    Gauge,
    Gavel,
    Gem,
    Ghost,
    Gift,
    GitBranch,
    GitBranchPlus,
    GitCommitHorizontal,
    GitCommitVertical,
    GitCompare,
    GitCompareArrows,
    GitFork,
    GitGraph,
    GitMerge,
    GitPullRequest,
    GitPullRequestArrow,
    GitPullRequestClosed,
    GitPullRequestCreate,
    GitPullRequestCreateArrow,
    GitPullRequestDraft,
    Github,
    Gitlab,
    GlassWater,
    Glasses,
    Globe,
    GlobeLock,
    Goal,
    Grab,
    GraduationCap,
    Grape,
    Grid2x2,
    Grid2x2Check,
    Grid2x2Plus,
    Grid2x2X,
    Grid3x3,
    Grip,
    GripHorizontal,
    GripVertical,
    Group,
    Guitar,
    Ham,
    Hammer,
    Hand,
    HandCoins,
    HandHeart,
    HandHelping,
    HandMetal,
    HandPlatter,
    Handshake,
    HardDrive,
    HardDriveDownload,
    HardDriveUpload,
    HardHat,
    Hash,
    Haze,
    HdmiPort,
    Heading,
    Heading1,
    Heading2,
    Heading3,
    Heading4,
    Heading5,
    Heading6,
    HeadphoneOff,
    Headphones,
    Headset,
    Heart,
    HeartCrack,
    HeartHandshake,
    HeartOff,
    HeartPulse,
    Heater,
    Hexagon,
    Highlighter,
    History,
    Hop,
    HopOff,
    Hospital,
    Hotel,
    Hourglass,
    House,
    HousePlug,
    HousePlus,
    IceCreamBowl,
    IceCreamCone,
    IdCard,
    Image,
    ImageDown,
    ImageMinus,
    ImageOff,
    ImagePlay,
    ImagePlus,
    ImageUp,
    Images,
    Import,
    Inbox,
    IndentDecrease,
    IndentIncrease,
    IndianRupee,
    Infinity,
    Info,
    InspectionPanel,
    Instagram,
    Italic,
    IterationCcw,
    IterationCw,
    JapaneseYen,
    Joystick,
    Kanban,
    Key,
    KeyRound,
    KeySquare,
    Keyboard,
    KeyboardMusic,
    KeyboardOff,
    Lamp,
    LampCeiling,
    LampDesk,
    LampFloor,
    LampWallDown,
    LampWallUp,
    LandPlot,
    Landmark,
    Languages,
    Laptop,
    LaptopMinimal,
    LaptopMinimalCheck,
    Lasso,
    LassoSelect,
    Laugh,
    Layers,
    Layers2,
    Layers3,
    LayoutDashboard,
    LayoutGrid,
    LayoutList,
    LayoutPanelLeft,
    LayoutPanelTop,
    LayoutTemplate,
    Leaf,
    LeafyGreen,
    Lectern,
    LetterText,
    Library,
    LibraryBig,
    LifeBuoy,
    Ligature,
    Lightbulb,
    LightbulbOff,
    Link,
    Link2,
    Link2Off,
    Linkedin,
    List,
    ListCheck,
    ListChecks,
    ListCollapse,
    ListEnd,
    ListFilter,
    ListMinus,
    ListMusic,
    ListOrdered,
    ListPlus,
    ListRestart,
    ListStart,
    ListTodo,
    ListTree,
    ListVideo,
    ListX,
    Loader,
    LoaderCircle,
    LoaderPinwheel,
    Locate,
    LocateFixed,
    LocateOff,
    Lock,
    LockKeyhole,
    LockKeyholeOpen,
    LockOpen,
    LogIn,
    LogOut,
    Logs,
    Lollipop,
    Luggage,
    Magnet,
    Mail,
    MailCheck,
    MailMinus,
    MailOpen,
    MailPlus,
    MailQuestion,
    MailSearch,
    MailWarning,
    MailX,
    Mailbox,
    Mails,
    Map,
    MapPin,
    MapPinCheck,
    MapPinCheckInside,
    MapPinHouse,
    MapPinMinus,
    MapPinMinusInside,
    MapPinOff,
    MapPinPlus,
    MapPinPlusInside,
    MapPinX,
    MapPinXInside,
    MapPinned,
    Martini,
    Maximize,
    Maximize2,
    Medal,
    Megaphone,
    MegaphoneOff,
    Meh,
    MemoryStick,
    Menu,
    Merge,
    MessageCircle,
    MessageCircleCode,
    MessageCircleDashed,
    MessageCircleHeart,
    MessageCircleMore,
    MessageCircleOff,
    MessageCirclePlus,
    MessageCircleQuestion,
    MessageCircleReply,
    MessageCircleWarning,
    MessageCircleX,
    MessageSquare,
    MessageSquareCode,
    MessageSquareDashed,
    MessageSquareDiff,
    MessageSquareDot,
    MessageSquareHeart,
    MessageSquareLock,
    MessageSquareMore,
    MessageSquareOff,
    MessageSquarePlus,
    MessageSquareQuote,
    MessageSquareReply,
    MessageSquareShare,
    MessageSquareText,
    MessageSquareWarning,
    MessageSquareX,
    MessagesSquare,
    Mic,
    MicOff,
    MicVocal,
    Microchip,
    Microscope,
    Microwave,
    Milestone,
    Milk,
    MilkOff,
    Minimize,
    Minimize2,
    Minus,
    Monitor,
    MonitorCheck,
    MonitorCog,
    MonitorDot,
    MonitorDown,
    MonitorOff,
    MonitorPause,
    MonitorPlay,
    MonitorSmartphone,
    MonitorSpeaker,
    MonitorStop,
    MonitorUp,
    MonitorX,
    Moon,
    MoonStar,
    Mountain,
    MountainSnow,
    Mouse,
    MouseOff,
    MousePointer,
    MousePointer2,
    MousePointerBan,
    MousePointerClick,
    Move,
    Move3d,
    MoveDiagonal,
    MoveDiagonal2,
    MoveDown,
    MoveDownLeft,
    MoveDownRight,
    MoveHorizontal,
    MoveLeft,
    MoveRight,
    MoveUp,
    MoveUpLeft,
    MoveUpRight,
    MoveVertical,
    Music,
    Music2,
    Music3,
    Music4,
    Navigation,
    Navigation2,
    Navigation2Off,
    NavigationOff,
    Network,
    Newspaper,
    Nfc,
    Notebook,
    NotebookPen,
    NotebookTabs,
    NotebookText,
    NotepadText,
    NotepadTextDashed,
    Nut,
    NutOff,
    Octagon,
    OctagonAlert,
    OctagonMinus,
    OctagonPause,
    OctagonX,
    Omega,
    Option,
    Orbit,
    Origami,
    Package,
    Package2,
    PackageCheck,
    PackageMinus,
    PackageOpen,
    PackagePlus,
    PackageSearch,
    PackageX,
    PaintBucket,
    PaintRoller,
    Paintbrush,
    PaintbrushVertical,
    Palette,
    PanelBottom,
    PanelBottomClose,
    PanelBottomDashed,
    PanelBottomOpen,
    PanelLeft,
    PanelLeftClose,
    PanelLeftDashed,
    PanelLeftOpen,
    PanelRight,
    PanelRightClose,
    PanelRightDashed,
    PanelRightOpen,
    PanelTop,
    PanelTopClose,
    PanelTopDashed,
    PanelTopOpen,
    PanelsLeftBottom,
    PanelsRightBottom,
    PanelsTopLeft,
    Paperclip,
    Parentheses,
    ParkingMeter,
    PartyPopper,
    Pause,
    PawPrint,
    PcCase,
    Pen,
    PenLine,
    PenOff,
    PenTool,
    Pencil,
    PencilLine,
    PencilOff,
    PencilRuler,
    Pentagon,
    Percent,
    PersonStanding,
    PhilippinePeso,
    Phone,
    PhoneCall,
    PhoneForwarded,
    PhoneIncoming,
    PhoneMissed,
    PhoneOff,
    PhoneOutgoing,
    Pi,
    Piano,
    Pickaxe,
    PictureInPicture,
    PictureInPicture2,
    PiggyBank,
    Pilcrow,
    PilcrowLeft,
    PilcrowRight,
    Pill,
    PillBottle,
    Pin,
    PinOff,
    Pipette,
    Pizza,
    Plane,
    PlaneLanding,
    PlaneTakeoff,
    Play,
    Plug,
    Plug2,
    PlugZap,
    Plus,
    Pocket,
    PocketKnife,
    Podcast,
    Pointer,
    PointerOff,
    Popcorn,
    Popsicle,
    PoundSterling,
    Power,
    PowerOff,
    Presentation,
    Printer,
    PrinterCheck,
    Projector,
    Proportions,
    Puzzle,
    Pyramid,
    QrCode,
    Quote,
    Rabbit,
    Radar,
    Radiation,
    Radical,
    Radio,
    RadioReceiver,
    RadioTower,
    Radius,
    RailSymbol,
    Rainbow,
    Rat,
    Ratio,
    Receipt,
    ReceiptCent,
    ReceiptEuro,
    ReceiptIndianRupee,
    ReceiptJapaneseYen,
    ReceiptPoundSterling,
    ReceiptRussianRuble,
    ReceiptSwissFranc,
    ReceiptText,
    RectangleEllipsis,
    RectangleHorizontal,
    RectangleVertical,
    Recycle,
    Redo,
    Redo2,
    RedoDot,
    RefreshCcw,
    RefreshCcwDot,
    RefreshCw,
    RefreshCwOff,
    Refrigerator,
    Regex,
    RemoveFormatting,
    Repeat,
    Repeat1,
    Repeat2,
    Replace,
    ReplaceAll,
    Reply,
    ReplyAll,
    Rewind,
    Ribbon,
    Rocket,
    RockingChair,
    RollerCoaster,
    Rotate3d,
    RotateCcw,
    RotateCcwSquare,
    RotateCw,
    RotateCwSquare,
    Route,
    RouteOff,
    Router,
    Rows2,
    Rows3,
    Rows4,
    Rss,
    Ruler,
    RussianRuble,
    Sailboat,
    Salad,
    Sandwich,
    Satellite,
    SatelliteDish,
    Save,
    SaveAll,
    SaveOff,
    Scale,
    Scale3d,
    Scaling,
    Scan,
    ScanBarcode,
    ScanEye,
    ScanFace,
    ScanLine,
    ScanQrCode,
    ScanSearch,
    ScanText,
    School,
    Scissors,
    ScissorsLineDashed,
    ScreenShare,
    ScreenShareOff,
    Scroll,
    ScrollText,
    Search,
    SearchCheck,
    SearchCode,
    SearchSlash,
    SearchX,
    Section,
    Send,
    SendHorizontal,
    SendToBack,
    SeparatorHorizontal,
    SeparatorVertical,
    Server,
    ServerCog,
    ServerCrash,
    ServerOff,
    Settings,
    Settings2,
    Shapes,
    Share,
    Share2,
    Sheet,
    Shell,
    Shield,
    ShieldAlert,
    ShieldBan,
    ShieldCheck,
    ShieldEllipsis,
    ShieldHalf,
    ShieldMinus,
    ShieldOff,
    ShieldPlus,
    ShieldQuestion,
    ShieldX,
    Ship,
    ShipWheel,
    Shirt,
    ShoppingBag,
    ShoppingBasket,
    ShoppingCart,
    Shovel,
    ShowerHead,
    Shrink,
    Shrub,
    Shuffle,
    Sigma,
    Signal,
    SignalHigh,
    SignalLow,
    SignalMedium,
    SignalZero,
    Signature,
    Signpost,
    SignpostBig,
    Siren,
    SkipBack,
    SkipForward,
    Skull,
    Slack,
    Slash,
    Slice,
    SlidersHorizontal,
    SlidersVertical,
    Smartphone,
    SmartphoneCharging,
    SmartphoneNfc,
    Smile,
    SmilePlus,
    Snail,
    Snowflake,
    Sofa,
    Soup,
    Space,
    Spade,
    Sparkle,
    Sparkles,
    Speaker,
    Speech,
    SpellCheck,
    SpellCheck2,
    Spline,
    Split,
    SprayCan,
    Sprout,
    Square,
    SquareActivity,
    SquareArrowDown,
    SquareArrowDownLeft,
    SquareArrowDownRight,
    SquareArrowLeft,
    SquareArrowOutDownLeft,
    SquareArrowOutDownRight,
    SquareArrowOutUpLeft,
    SquareArrowOutUpRight,
    SquareArrowRight,
    SquareArrowUp,
    SquareArrowUpLeft,
    SquareArrowUpRight,
    SquareAsterisk,
    SquareBottomDashedScissors,
    SquareChartGantt,
    SquareCheck,
    SquareCheckBig,
    SquareChevronDown,
    SquareChevronLeft,
    SquareChevronRight,
    SquareChevronUp,
    SquareCode,
    SquareDashed,
    SquareDashedBottom,
    SquareDashedBottomCode,
    SquareDashedKanban,
    SquareDashedMousePointer,
    SquareDivide,
    SquareDot,
    SquareEqual,
    SquareFunction,
    SquareKanban,
    SquareLibrary,
    SquareM,
    SquareMenu,
    SquareMinus,
    SquareMousePointer,
    SquareParking,
    SquareParkingOff,
    SquarePen,
    SquarePercent,
    SquarePi,
    SquarePilcrow,
    SquarePlay,
    SquarePlus,
    SquarePower,
    SquareRadical,
    SquareScissors,
    SquareSigma,
    SquareSlash,
    SquareSplitHorizontal,
    SquareSplitVertical,
    SquareSquare,
    SquareStack,
    SquareTerminal,
    SquareUser,
    SquareUserRound,
    SquareX,
    Squircle,
    Squirrel,
    Stamp,
    Star,
    StarHalf,
    StarOff,
    StepBack,
    StepForward,
    Stethoscope,
    Sticker,
    StickyNote,
    Store,
    StretchHorizontal,
    StretchVertical,
    Strikethrough,
    Subscript,
    Sun,
    SunDim,
    SunMedium,
    SunMoon,
    SunSnow,
    Sunrise,
    Sunset,
    Superscript,
    SwatchBook,
    SwissFranc,
    SwitchCamera,
    Sword,
    Swords,
    Syringe,
    Table,
    Table2,
    TableCellsMerge,
    TableCellsSplit,
    TableColumnsSplit,
    TableOfContents,
    TableProperties,
    TableRowsSplit,
    Tablet,
    TabletSmartphone,
    Tablets,
    Tag,
    Tags,
    Tally1,
    Tally2,
    Tally3,
    Tally4,
    Tally5,
    Tangent,
    Target,
    Telescope,
    Tent,
    TentTree,
    Terminal,
    TestTube,
    TestTubeDiagonal,
    TestTubes,
    Text,
    TextCursor,
    TextCursorInput,
    TextQuote,
    TextSearch,
    TextSelect,
    Theater,
    Thermometer,
    ThermometerSnowflake,
    ThermometerSun,
    ThumbsDown,
    ThumbsUp,
    Ticket,
    TicketCheck,
    TicketMinus,
    TicketPercent,
    TicketPlus,
    TicketSlash,
    TicketX,
    Tickets,
    TicketsPlane,
    Timer,
    TimerOff,
    TimerReset,
    ToggleLeft,
    ToggleRight,
    Toilet,
    Tornado,
    Torus,
    Touchpad,
    TouchpadOff,
    TowerControl,
    ToyBrick,
    Tractor,
    TrafficCone,
    TrainFront,
    TrainFrontTunnel,
    TrainTrack,
    TramFront,
    Trash,
    Trash2,
    TreeDeciduous,
    TreePalm,
    TreePine,
    Trees,
    Trello,
    TrendingDown,
    TrendingUp,
    TrendingUpDown,
    Triangle,
    TriangleAlert,
    TriangleRight,
    Trophy,
    Truck,
    Turtle,
    Tv,
    TvMinimal,
    TvMinimalPlay,
    Twitch,
    Twitter,
    Type,
    TypeOutline,
    Umbrella,
    UmbrellaOff,
    Underline,
    Undo,
    Undo2,
    UndoDot,
    UnfoldHorizontal,
    UnfoldVertical,
    Ungroup,
    University,
    Unlink,
    Unlink2,
    Unplug,
    Upload,
    Usb,
    User,
    UserCheck,
    UserCog,
    UserMinus,
    UserPen,
    UserPlus,
    UserRound,
    UserRoundCheck,
    UserRoundCog,
    UserRoundMinus,
    UserRoundPen,
    UserRoundPlus,
    UserRoundSearch,
    UserRoundX,
    UserSearch,
    UserX,
    Users,
    UsersRound,
    Utensils,
    UtensilsCrossed,
    UtilityPole,
    Variable,
    Vault,
    Vegan,
    VenetianMask,
    Vibrate,
    VibrateOff,
    Video,
    VideoOff,
    Videotape,
    View,
    Voicemail,
    Volleyball,
    Volume,
    Volume1,
    Volume2,
    VolumeOff,
    VolumeX,
    Vote,
    Wallet,
    WalletCards,
    WalletMinimal,
    Wallpaper,
    Wand,
    WandSparkles,
    Warehouse,
    WashingMachine,
    Watch,
    Waves,
    Waypoints,
    Webcam,
    Webhook,
    WebhookOff,
    Weight,
    Wheat,
    WheatOff,
    WholeWord,
    Wifi,
    WifiHigh,
    WifiLow,
    WifiOff,
    WifiZero,
    Wind,
    WindArrowDown,
    Wine,
    WineOff,
    Workflow,
    Worm,
    WrapText,
    Wrench,
    X,
    Youtube,
    Zap,
    ZapOff,
    ZoomIn,
    ZoomOut
}