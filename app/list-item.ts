
export const LIST_ITEMS : ListItem[] = [
    { id: "1", title: "Appelsiinit", created: null, updated: null, category: null},
    { id: "2", title: "Kirjolohi", created: null, updated: null, category: null},
    { id: "3", title: "Salmiakki", created: null, updated: null, category: null},
    { id: "4", title: "Vaipat", created: null, updated: null, category: null},
    { id: "5", title: "Vesimeloni", created: null, updated: null, category: null},
    { id: "6", title: "Banaanit", created: null, updated: null, category: null}
];

export class ListItem {
    id : string;
    created : Date;
    updated : Date;
    title : string;
    category : string;
}