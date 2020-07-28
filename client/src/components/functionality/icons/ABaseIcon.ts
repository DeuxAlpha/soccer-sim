import {Prop, Vue} from "vue-property-decorator";

export class ABaseIcon extends Vue {
  @Prop({type: String, default: '32px'}) readonly size!: string;
}